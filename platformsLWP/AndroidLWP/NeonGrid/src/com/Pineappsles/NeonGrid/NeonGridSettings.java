package com.Pineappsles.NeonGrid;

import net.margaritov.preference.colorpicker.ColorPickerPreference;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.Preference;
import android.preference.PreferenceActivity;
import android.preference.Preference.OnPreferenceChangeListener;
import android.view.View;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

/**
 * Preference change listener.
 */
public class NeonGridSettings extends PreferenceActivity implements SharedPreferences.OnSharedPreferenceChangeListener,  SeekBar.OnSeekBarChangeListener {
	private SeekBar mSeekBar;
	
	
	
	
	
	@Override
	public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String key) {
	}

	@Override
	protected void onCreate(Bundle icicle) {
		super.onCreate(icicle);

		getPreferenceManager().setSharedPreferencesName(NeonGrid.SHARED_PREFS_NAME);
		addPreferencesFromResource(R.xml.wallpaper_settings);
		getPreferenceManager().getSharedPreferences().registerOnSharedPreferenceChangeListener(this);
			 
		
		
	
		
		
		// get value of color picker PRIMARY
	      ((ColorPickerPreference)findPreference("color2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

				@Override
				public boolean onPreferenceChange(Preference preference, Object newValue) {
					String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
				
					// set up values
					int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
					int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
					int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
					float finalRed = (float) (red/255.00);
					float finalGreen = (float) (green/255.0);
					float finalBlue = (float) (blue/255.0);
					
					// save values for unity message
					SharedPreferences myPrefsPlayer = getSharedPreferences("NeonGridLWSettings", 0);
					SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
					prefsEditorPlayer.putFloat("redVal", finalRed );
					prefsEditorPlayer.putFloat("greenVal", finalGreen );
					prefsEditorPlayer.putFloat("blueVal", finalBlue );
					prefsEditorPlayer.commit();
					
					return true;
				}

	        });
	        ((ColorPickerPreference)findPreference("color2")).setAlphaSliderEnabled(false);
	        
	        
	        
	     // get value of color picker SECONDARY
		      ((ColorPickerPreference)findPreference("color3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

					@Override
					public boolean onPreferenceChange(Preference preference, Object newValue) {
						String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
					
						// set up values
						int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
						int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
						int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
						float finalRed = (float) (red/255.00);
						float finalGreen = (float) (green/255.0);
						float finalBlue = (float) (blue/255.0);
						
						// save values for unity message
						SharedPreferences myPrefsPlayer = getSharedPreferences("NeonGridLWSettings", 0);
						SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
						prefsEditorPlayer.putFloat("redVal2", finalRed );
						prefsEditorPlayer.putFloat("greenVal2", finalGreen );
						prefsEditorPlayer.putFloat("blueVal2", finalBlue );
						prefsEditorPlayer.commit();
						
						return true;
					}

		        });
		        ((ColorPickerPreference)findPreference("color3")).setAlphaSliderEnabled(false);
			
	        
		
	}

	
	@Override
	protected void onDestroy() {
		getPreferenceManager().getSharedPreferences().unregisterOnSharedPreferenceChangeListener(this);
		super.onDestroy();
	}

	@Override
	public void onProgressChanged(SeekBar seekBar, int progress,
			boolean fromUser) {
		// TODO Auto-generated method stub
	
	    if (mSeekBar != null)
	      mSeekBar.setProgress(progress); 
	    
	 // save values for unity message
		SharedPreferences myPrefsPlayer = getSharedPreferences("NeonGridLWSettings", 0);
		SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
		prefsEditorPlayer.putInt("seek", progress );
		prefsEditorPlayer.commit();
		
	// would update a text view here
		//tv.setText(Integer.toString(progress)+"%");
	
		
	}

	@Override
	public void onStartTrackingTouch(SeekBar seekBar) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onStopTrackingTouch(SeekBar seekBar) {
		// TODO Auto-generated method stub
		
	}

	
	
	
	
}
