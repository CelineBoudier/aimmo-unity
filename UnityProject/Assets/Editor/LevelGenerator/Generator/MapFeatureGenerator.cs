﻿using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MapFeatures;
using SimpleJSON;
using InjectorNS;

namespace GeneratorNS {
	public abstract class MapFeatureGenerator: IGenerator 
	{
		public string ToJson()
		{
			string incompleteJson = MapFeatureToJson();

			string fullJson =  @"{
				" + incompleteJson + @"
	    		}";
			
			return fullJson;
		}

		public GameObject GenerateObject(string id)
		{
			IMapFeatureManager manager = GetManager ();
			MapFeatureData mfd = new MapFeatureData (JSON.Parse (ToJson ()));
			manager.Create (id, mfd);

			GameObject gameObject = GameObject.Find (manager.MapFeatureId (id));
			injectGenerator (gameObject);

			return gameObject;
		}

		private void injectGenerator (GameObject gameObject)
		{
			Injector wrapper = gameObject.AddComponent<Injector>();
			wrapper.Set<IGenerator> ((IGenerator) this);
		}

		public abstract string MapFeatureToJson();
		public abstract IMapFeatureManager GetManager ();
	}
}