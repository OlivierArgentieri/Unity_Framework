using System;
using Unity_Framework.Scripts.Path.PathManager.PathMode.PathModes;

namespace Unity_Framework.Scripts.Path.PathManager.PathMode
{
    [Serializable]
    public class UF_PathModeSelector
    {
        #region f/p

        public UF_PathType Type = UF_PathType.Line;
    
    
        // modes
        public UF_PathLineMode LineMode = new UF_PathLineMode();
     //   public UF_LineMode LineMode= new UF_LineMode();
        
        public UF_PathMode Mode
        {
            get
            {
                switch (Type)
                {
                    case UF_PathType.Line:
                        return LineMode;

                  
                   /* case UF_PathType.Curve:
                        return BezierMode;*/
                }

                return null;
            }
        }
        #endregion
    }

    public enum UF_PathType
    {
        Curve,
        Line,
    
    }
}