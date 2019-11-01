using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Polybrush
{
	public class z_About : EditorWindow
	{
		private static string CHANGELOG_PATH { get { return z_EditorUtility.RootFolder + "Documentation/changelog.md"; } }

        private const string VERSION_NUMBER_PATTERN = "(?<=#\\sPolybrush\\s)([0-9]{1,2}\\.[0-9]{1,2}\\.[0-9]{1,2}([a-z]|[A-Z])[0-9]{1,2})";
        private string versionNumber = "Major.Minor.Patch";

        private void OnEnable()
		{
			changelog = System.IO.File.ReadAllText(CHANGELOG_PATH);

			Match versionMatch = Regex.Match(changelog, VERSION_NUMBER_PATTERN);
			if(versionMatch.Success) versionNumber = versionMatch.Value;

			// Match vcsMatch = Regex.Match(changelog, GIT_REVISION_PATTERN);
			// if(vcsMatch.Success) revisionNumber = vcsMatch.Value;
		}

        private string changelog;
        private GUIStyle centeredLargeLabel = null, centeredExtraLargeLabel = null;
        private bool initialized = false;
        private Vector2 scroll = Vector2.zero;

        private void BeginHorizontalCenter()
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
		}

        private void EndHorizontalCenter()
		{
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}

        private void OnGUI()
		{
			if(!initialized)
			{
				centeredLargeLabel = new GUIStyle( EditorStyles.largeLabel );
				centeredLargeLabel.alignment = TextAnchor.MiddleCenter;
				centeredExtraLargeLabel = new GUIStyle( EditorStyles.largeLabel );
				centeredExtraLargeLabel.fontSize += 18;
				centeredExtraLargeLabel.alignment = TextAnchor.MiddleCenter;
				EditorStyles.largeLabel.richText = true;
			}

			GUILayout.Space(12);

			GUILayout.Label("Polybrush " + versionNumber, centeredExtraLargeLabel);

			// if(GUILayout.Button(revisionNumber, centeredLargeLabel))
			// 	 Application.OpenURL("https://github.com/procore3d/polybrush/commit/" + revisionNumber);

			GUILayout.Space(12);

			BeginHorizontalCenter();

			if(GUILayout.Button(" Documentation "))
				Application.OpenURL(z_Pref.DocumentationLink);

			if(GUILayout.Button(" Website "))
				Application.OpenURL(z_Pref.WebsiteLink);
				
			EndHorizontalCenter();

			BeginHorizontalCenter();

			if(GUILayout.Button(" Contact "))
				Application.OpenURL(z_Pref.ContactLink);

			GUILayout.Space(12);
			
			EndHorizontalCenter();

			GUILayout.Label("<b>Changelog</b>", EditorStyles.largeLabel);

			scroll = GUILayout.BeginScrollView(scroll);

			GUILayout.Label( changelog );

			GUILayout.EndScrollView();
		}
	}
}
