package com.Pineappsles.NeonGrid;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceActivity;

/**
 * Preference change listener.
 */
public class NeonGridSettings extends PreferenceActivity implements SharedPreferences.OnSharedPreferenceChangeListener {

	@Override
	public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String key) {
	}

	@Override
	protected void onCreate(Bundle icicle) {
		super.onCreate(icicle);

		getPreferenceManager().setSharedPreferencesName(NeonGrid.SHARED_PREFS_NAME);
		addPreferencesFromResource(R.xml.wallpaper_settings);
		getPreferenceManager().getSharedPreferences().registerOnSharedPreferenceChangeListener(this);

	}

	@Override
	protected void onDestroy() {
		getPreferenceManager().getSharedPreferences().unregisterOnSharedPreferenceChangeListener(this);
		super.onDestroy();
	}

}
