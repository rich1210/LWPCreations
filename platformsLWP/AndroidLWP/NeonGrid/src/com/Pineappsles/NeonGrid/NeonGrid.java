package com.Pineappsles.NeonGrid;

import android.app.WallpaperInfo;
import android.app.WallpaperManager;
import android.content.ComponentName;
import android.content.Intent;
import android.content.SharedPreferences;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.GestureDetector.OnDoubleTapListener;
import android.view.SurfaceHolder;
import android.widget.Toast;

import com.mirage.livewallpaper.glLibrary.*;
import com.unity3d.player.UnityPlayer;

/***
 * 
 * @see http
 *      ://developer.android.com/reference/android/service/wallpaper/package-
 *      summary.html
 */
public class NeonGrid extends GLWallpaperService implements SharedPreferences.OnSharedPreferenceChangeListener {
	private UnityPlayer player;
	private GLES20Unity renderer;
	private int glesVersion = 2;
	private GestureDetector gd;
	private GestureLstr simulateSwipe;
	public static final String SHARED_PREFS_NAME = "NeonGridLWSettings";
	private SharedPreferences pPrefs;

	private boolean enableDoubleTap = true;
	private boolean rotateCubes = true;
	private boolean swipeEmul = false;

	/**
	 * Called by the system when the service is first created. Do not call this
	 * method directly.
	 */
	public void onCreate() {

		super.onCreate();
		
		player = new UnityPlayer(this);

		// Default gles_mode is 2.0
		glesVersion = player.getSettings().getInt("gles_mode", 2);

		renderer = new GLES20Unity(player, glesVersion);

		// Simulate Swipe
		simulateSwipe = new GestureLstr();

		pPrefs = getSharedPreferences(SHARED_PREFS_NAME, 0);
		pPrefs.registerOnSharedPreferenceChangeListener(this);

	}

	/**
	 * Called by the system to notify a Service that it is no longer used and is
	 * being removed.
	 */
	public void onDestroy() {
	
		super.onDestroy();
	
		if (player != null)
			player.quit();
	}

	class WallpaperEngine extends GLWallpaperService$GLEngine {

		public WallpaperEngine(GLWallpaperService paramGLWallpaperService) {
			super(paramGLWallpaperService);

			setEGLContextFactory(new ContextFactory(glesVersion));
			setEGLConfigChooser(new ConfigChooser(5, 6, 5, 0, 16, 0));

			setRenderer(renderer);

			setRenderMode(RENDERMODE_CONTINUOUSLY);

			/**
			 * Double tap anywhere on the home screen opens live wallpaper
			 * settings menu
			 */
			gd = new GestureDetector(paramGLWallpaperService, simulateSwipe);

			// set the Double tap listener (Opens Settings Activity)
			gd.setOnDoubleTapListener(new OnDoubleTapListener() {
				@Override
				public boolean onDoubleTap(MotionEvent e) {
					if (enableDoubleTap)
						StartActivity();

					return false;
				}

				@Override
				public boolean onDoubleTapEvent(MotionEvent e) {
					return false;
				}

				@Override
				public boolean onSingleTapConfirmed(MotionEvent e) {
					return false;
				}
			});

			/**
			 * Gets user preferences.
			 */
			getInitPref();

		}

		/**
		 * Wallpaper is running when visible and paused when hidden. This way
		 * the wallpaper only uses CPU when it is visible.
		 * 
		 */
		public void onVisibilityChanged(boolean visible) {
			boolean reportedVisible = isVisible();

			if (reportedVisible == false && visible == true) {
				return;
			}

			super.onVisibilityChanged(visible);

			if (player != null) {
				if (visible) {
					player.resume();
					renderer.PauseMediaVolume("401");
				} else {
					player.pause();
				}
			}
			
		}

	
		public void onSurfaceCreated(SurfaceHolder holder) {
			
			
			if (player != null) {
				if (isVisible())
					player.resume();
				else
					player.pause();
			}

			super.onSurfaceCreated(holder);
		}

		/**
		 * Called to inform you of the wallpaper's offsets changing within its
		 * contain, corresponding to the container's call to
		 * WallpaperManager.setWallpaperOffsets().
		 * 
		 * @see http 
		 *      ://developer.android.com/reference/android/app/WallpaperManager
		 *      .html#setWallpaperOffsets(android.os.IBinder, float, float)
		 */
		public void onOffsetsChanged(float xOffset, float yOffset, float xOffsetStep, float yOffsetStep, int xPixelOffset, int yPixelOffset) {
			super.onOffsetsChanged(xOffset, yOffset, xOffsetStep, yOffsetStep, xPixelOffset, yPixelOffset);

			if (player != null && !isPreview() && !swipeEmul) {
				/**
				 * Method "SetCamOffset" is in Unity's demo scene attached to
				 * the "Main Camera" inside the script "HomeSwitch"
				 */
				UnityPlayer.UnitySendMessage("Main Camera", "SetCamOffset", String.valueOf(xOffset));
				
				Toast.makeText(getBaseContext(), "change", Toast.LENGTH_LONG).show();

			}
		}

		/**
		 * Touch-screen interaction with the window that is showing this
		 * wallpaper. Touch events are manually sent to UnityPlayer because
		 * player.onTouchEvent doesn't work when we rotate the device.
		 */
		public void onTouchEvent(MotionEvent paramMotionEvent) {
			if (player != null) 
				{
							
					if ( paramMotionEvent.getAction() == MotionEvent.ACTION_UP )
						{
						 UnityPlayer.UnitySendMessage("Main Camera", "IsTouching", "no");
						}
					if ( paramMotionEvent.getAction() == MotionEvent.ACTION_DOWN )
						{
						 UnityPlayer.UnitySendMessage("Main Camera", "IsTouching", "yes");
						}
					
					UnityPlayer.UnitySendMessage("Main Camera", "SendTouchXY", (paramMotionEvent.getX() + "," + paramMotionEvent.getY()));

					
				}
			gd.onTouchEvent(paramMotionEvent);
		}

	}

	/**
	 * Return a new instance of the wallpaper's engine.
	 */
	@Override
	public Engine onCreateEngine() {
		final Engine myEngine = new WallpaperEngine(this);
		myEngine.setTouchEventsEnabled(true);

		return myEngine;
	}

	/**
	 * Called when a shared preference is changed, added, or removed.
	 */
	@Override
	public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String key) {
		getInitPref();
	}

	/**
	 * Loads preferences made by the user in lwp settings
	 */
	private void getInitPref() {
		/**
		 * Enable/disable double tap
		 */
		enableDoubleTap = this.pPrefs.getBoolean("doubleTap", true);

		rotateCubes = this.pPrefs.getBoolean("rotate", true);
		/**
		 * The method "SetRotation" exists in Unity attached to the
		 * "Main Camera" inside the script "HomeSwitch"
		 */
		
		if (rotateCubes)
			UnityPlayer.UnitySendMessage("Main Camera", "SetRotation", "yes");
		else
			UnityPlayer.UnitySendMessage("Main Camera", "SetRotation", "no");

		/**
		 * Reads from settings file if we should enable or disable swipe
		 * (emulated)
		 */
		swipeEmul = this.pPrefs.getBoolean("swipeEmul", false);
		simulateSwipe.isEnabled(swipeEmul);
		
		
		// send unity color values, default is 1.0 PRIMARY
		SharedPreferences myPrefsPlayer = getSharedPreferences("NeonGridLWSettings", 0);
	
		UnityPlayer.UnitySendMessage("Main Camera", "SetR1", String.valueOf(myPrefsPlayer.getFloat("redVal", 1F)));
		
		UnityPlayer.UnitySendMessage("Main Camera", "SetG1", String.valueOf(myPrefsPlayer.getFloat("greenVal", 1F)));
		
		UnityPlayer.UnitySendMessage("Main Camera", "SetB1", String.valueOf(myPrefsPlayer.getFloat("blueVal", 1F)));
				
				
		// send unity color values, default is 1.0 SECONDARY
		UnityPlayer.UnitySendMessage("Main Camera", "SetR2", String.valueOf(myPrefsPlayer.getFloat("redVal2", 1F)));
		
		UnityPlayer.UnitySendMessage("Main Camera", "SetG2", String.valueOf(myPrefsPlayer.getFloat("greenVal2", 1F)));
		
		UnityPlayer.UnitySendMessage("Main Camera", "SetB2", String.valueOf(myPrefsPlayer.getFloat("blueVal2", 1F)));
		
		// percent default 50
		UnityPlayer.UnitySendMessage("Main Camera", "SetColorChance", String.valueOf(myPrefsPlayer.getInt("seek", 50)));

	}

	/**
	 * Starts new activity (settings menu).
	 */
	public void StartActivity() {

		WallpaperInfo localWallpaperInfo = ((WallpaperManager) getSystemService("wallpaper")).getWallpaperInfo();
		if (localWallpaperInfo != null) {
			String str1 = localWallpaperInfo.getSettingsActivity();

			if (str1 != null) {
				String str2 = localWallpaperInfo.getPackageName();
				Intent localIntent1 = new Intent();
				ComponentName localComponentName = new ComponentName(str2, str1);
				localIntent1.setComponent(localComponentName);
				localIntent1.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
				startActivity(localIntent1);
			}
		}

	}
}
