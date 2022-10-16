using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIElement : MonoBehaviour
    {
        public Color DefaultColor { get; set; } = new Color(1, 0.6666667f, 0);
        public virtual void SetColor(Color color)
        {
        }
        public void ResetColor()
        {
            SetColor(DefaultColor);
        }
    }
}
