using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SlimDX;
using FDK;

namespace TJAPlayer3
{
    class CSongObject
    {
        public CSongObject(string name, float x, float y, string path)
        {
            this.name = path;
            this.visible = false;

            this.x = x;
            this.y = y;
            this.rotation = 0f;
            this.opacity = 255;
            this.xScale = 1.0f;
            this.yScale = 1.0f;

            this.texture = TJAPlayer3.Tx.TxCSong(path);
        }       

        public void tDraw()
        {
            if (this.texture == null) return;

            this.texture.fZ軸中心回転 = C変換.DegreeToRadian(this.rotation);
            this.texture.Opacity = this.opacity;
            if (visible) this.texture.t2D描画SongObj(TJAPlayer3.app.Device, this.x, this.y, this.xScale, this.yScale);
        }

        public void tDispose()
        {
            this.visible = false;
            if (this.texture == null) this.texture.Dispose();
        }

        public CTexture texture;

        public string name;
        public bool visible;

        public float x;
        public float y;
        public float rotation;
        public int opacity;
        public float xScale;
        public float yScale;
    }
}
