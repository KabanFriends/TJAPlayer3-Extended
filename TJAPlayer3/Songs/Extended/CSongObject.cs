using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
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
            this.color = new Color4(1f, 1f, 1f, 1f);
            this.frame = 0;

            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                textures = TJAPlayer3.Tx.TxCSongFolder(path);
            }else
            {
                textures = new CTexture[1];
                textures[0] = TJAPlayer3.Tx.TxCSong(path);
            }
        }       

        public void tDraw()
        {
            CTexture tx = this.textures[frame];
            if (frame + 1 > textures.Length) return;
            if (tx == null) return;

            tx.fZ軸中心回転 = C変換.DegreeToRadian(this.rotation);
            tx.color4 = this.color;
            tx.Opacity = this.opacity;
            if (visible) tx.t2D描画SongObj(TJAPlayer3.app.Device, this.x, this.y, this.xScale, this.yScale);
        }

        public void tDispose()
        {
            this.visible = false;
            foreach (CTexture tx in textures)
            {
                if (tx != null) tx.Dispose();
            }
        }

        public CTexture[] textures;

        public string name;
        public bool visible;

        public float x;
        public float y;
        public float rotation;
        public int opacity;
        public float xScale;
        public float yScale;
        public Color4 color;

        public int frame;
    }
}
