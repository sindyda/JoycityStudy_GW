using System;
using System.Collections.Generic;
using UnityEngine;

namespace CGCommand
{

    public interface ICGCommand
    {
        void Excute();
        void Undo();
    }


    public class BuildingMove : ICGCommand
    {
       
        public BuildingMove(EditBuildingPlayer player,int x,int y)
        {
            ExcuteFunc = () =>
            {
                player.Move(x, y);
            };

            UndoFunc = () =>
            {
                player.Move(-x, -y);
            };
        }

        private Action ExcuteFunc;
        private Action UndoFunc;

        public void Excute()
        {
            ExcuteFunc?.Invoke();
        }

        public void Undo()
        {
            UndoFunc?.Invoke();
        }
    }


    public class BuildingRotate : ICGCommand
    {
       
        public BuildingRotate(EditBuildingPlayer player)
        {
            
            ExcuteFunc = () =>
            {
                player.RotateOnce();
            };

            UndoFunc = () =>
            {
                player.RotateOnce_Reverse();
            };
        }

        private Action ExcuteFunc;
        private Action UndoFunc;

        public void Excute()
        {
            ExcuteFunc?.Invoke();
        }

        public void Undo()
        {
            UndoFunc?.Invoke();
        }
    }

    public class BuildingSelect : ICGCommand
    {
      
        public BuildingSelect(EditBuildingPlayer player, EditBuildingUnit unit)
        {
            ExcuteFunc = () =>
            {
                player.units.Add(unit);
            };

            UndoFunc = () =>
            {
                player.units.Remove(unit);
            };
            
        }

        private Action ExcuteFunc;
        private Action UndoFunc;

        public void Excute()
        {
            ExcuteFunc?.Invoke();
        }

        public void Undo()
        {
            UndoFunc?.Invoke();
        }
    }

    public class BuildingDeSelect : ICGCommand
    {
        public BuildingDeSelect(EditBuildingPlayer player, EditBuildingUnit unit)
        {
            ExcuteFunc = () =>
            {
                player.units.Remove(unit);
            };

            UndoFunc = () =>
            {
                player.units.Add(unit);
            };
        }

        private Action ExcuteFunc;
        private Action UndoFunc;

        public void Excute()
        {
            ExcuteFunc?.Invoke();
        }

        public void Undo()
        {
            UndoFunc?.Invoke();
        }
    }




    public enum EBuildingDirection : int
    {
        North =0,
        East = 1,
        South = 2,
        West = 3,
        
    }

    public class EditBuildingPlayer
    {
        public List<EditBuildingUnit> units = new List<EditBuildingUnit>();

        public void Move(int addx,int addy)
        {
            foreach(var unit in units)
            {
                unit.PosX += addx;
                unit.posY += addy;
            }
        }

        public void RotateOnce()
        {
            foreach (var unit in units)
            {
                var currentDir = unit.direction;
                var nextDir = (EBuildingDirection)((int)(unit.direction + 1) % EditBuildingUnit.DirMax);

                unit.direction = nextDir;
            }
        }
        public void RotateOnce_Reverse()
        {
            foreach (var unit in units)
            {
                var currentDir = unit.direction;
                var nextDir = (EBuildingDirection)((int)(unit.direction + 3) % EditBuildingUnit.DirMax);

                unit.direction = nextDir;
            }
        }
    }

    

    public class EditBuildingUnit 
    {
        public readonly static int DirMax = 4;
        public int PosX { get; set; }
        public int posY { get; set; }
        public EBuildingDirection direction { get; set; }

        public EditBuildingUnit(int ix,int iy,EBuildingDirection dir)
        {
            PosX = ix;
            posY = iy;
            direction = dir;
        }
        public (int x, int y) GetPosition() => (PosX, posY);
        public void MovePosition(int ix,int iy)
        {
            PosX += ix;
            posY += iy;
        }

        public void RotateBuilding(EBuildingDirection dir)
        {
            direction = dir;
        }
    }
}
