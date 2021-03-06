﻿using UnityEditor;
using UnityEngine;
using MapFeatures;

namespace Generator {
	public class ScorePointGenerator : SpriteGenerator
	{
		private const string defaultSprite = @"""sprite"" : {
			""width"" : ""400"",
			""height"" : ""400"",
			""path"" : ""Grass-400x400-isometric-top""
		}";
		
		public ScorePointGenerator (float x, float y, string sprite) : base (x, y, sprite) 
		{
		}

		public ScorePointGenerator (float x, float y) : base (x, y, defaultSprite) 
		{
		}

		public override IMapFeatureManager GetManager ()
		{
			return ObjectController.GetContext().AddComponent<ScorePointManager> ()  as IMapFeatureManager;
		}
	}
}
