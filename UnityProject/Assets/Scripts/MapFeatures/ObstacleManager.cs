﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class manages obstacles, i.e. the walls in the scene.
 */

namespace MapFeatures 
{
	public class ObstacleManager : MapFeatureManager 
	{
		public override void Draw(GameObject obstacle, Sprite obstacleSprite)
		{
			SpriteRenderer obstacleRenderer = obstacle.AddComponent<SpriteRenderer>();
			obstacleRenderer.sprite = obstacleSprite;
		}
			
		public override string MapFeatureId(string id)
		{
			return "obstacle" + id;
		}
	}
}
