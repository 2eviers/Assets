namespace Engine
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public static class TypedUnityEvents
    {
        [Serializable]
        public class IntEvent : UnityEvent<int> { }
        [Serializable]
        public class BoolEvent : UnityEvent<bool> { }
        [Serializable]
        public class FloatEvent : UnityEvent<float> { }
        [Serializable]
        public class StringEvent : UnityEvent<string> { }
        [Serializable]
        public class ColorEvent : UnityEvent<Color> { }
        [Serializable]
        public class StringArrayEvent : UnityEvent<string[]> { }
        [Serializable]
        public class ObjectEvent : UnityEvent<object> { }
        [Serializable]
        public class DateTimeEvent : UnityEvent<DateTime> { }
        [Serializable]
        public class ColliderEvent : UnityEvent<Collider> { }
        [Serializable]
        public class CollisionEvent : UnityEvent<Collision> { }
        [Serializable]
        public class Vector2Event : UnityEvent<Vector2> { }
        [Serializable]
        public class Vector3Event : UnityEvent<Vector3> { }
        [Serializable]
        public class Vector4Event : UnityEvent<Vector4> { }
        [Serializable]
        public class QuaternionEvent : UnityEvent<Quaternion> { }
        [Serializable]
        public class TransformEvent : UnityEvent<Transform> { }
        [Serializable]
        public class UnityObjectEvent : UnityEvent<UnityEngine.Object> { }
        [Serializable]
        public class GameObjectEvent : UnityEvent<GameObject> { }
        [Serializable]
        public class SpriteEvent : UnityEvent<Sprite> { }
        [Serializable]
        public class LongEvent : UnityEvent<long> { }
    }
}