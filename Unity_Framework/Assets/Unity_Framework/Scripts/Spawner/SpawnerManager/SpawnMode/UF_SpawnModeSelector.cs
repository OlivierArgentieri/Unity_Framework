using System;
using Unity_Framework.Scripts.Spawner.SpawnerManager.SpawnMode.SpawnModes;

namespace Unity_Framework.Scripts.Spawner.SpawnerManager.SpawnMode
{
    [Serializable]
    public class UF_SpawnModeSelector
    {
        #region f/p

        public UF_SpawnType Type = UF_SpawnType.Circle;
    
    
        // modes
        public UF_CircleMode CircleMode = new UF_CircleMode();
        public UF_LineMode LineMode= new UF_LineMode();
        public UF_PointMode PointMode = new UF_PointMode();

        public UF_SpawnMode Mode
        {
            get
            {
                switch (Type)
                {
                    case UF_SpawnType.Circle:
                        return CircleMode;

                    case UF_SpawnType.Line:
                        return LineMode;
                
                    case UF_SpawnType.Point:
                        return PointMode;
                }

                return null;
            }
        }
        #endregion
    }

    public enum UF_SpawnType
    {
        Circle,
        Line,
        Point
    }
}
