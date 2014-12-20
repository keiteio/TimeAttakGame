using UnityEngine;
using System.Collections;

public class Const {
	public class Character {
		public class MovablePosition {
			public class Vertical {
				public static readonly float STEP = 2.0f;
				public static readonly float MIN = -2.0f;
				public static readonly float MAX = 2.0f;
			}
		}
	}
	public class Camera {
		public class StartPosition {
			public static readonly float Z = -1500;
		}
		public class MainPosition {
			public static readonly float Z = -500;
		}
		public class GameOverPosition {
			public static readonly float Z = 500;
		}
	}
}