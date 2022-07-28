using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;
using Celeste;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [TrackedAs(typeof(Actor))]
    [Tracked(true)]
    [CustomEntity("VectorHelper/CustomHoldableBasic")]
    public class CustomHoldableBasic : Actor
    {
        private string spriteDirectory;
        private string spriteOffset;
        private string spriteOverlay;
        private string spriteOverlayOffset;
        private int depth;
        private bool killPlayerOnDestroy;
        private bool slowsPlayerDown;
        private Image _holdableSprite;
        private Image[] _spriteOverlay_ = new Image[32];
        private Holdable Hold;
        private Player player;
        private Vector2 spriteDisplacement;
        private Vector2 overlayDisplacement;

        
        public CustomHoldableBasic(EntityData data, Vector2 offset) : this(
            data.Position + offset,
            data.Attr("spriteDirectory", "objects/resortclutter/yellow_14"),
            data.Attr("spriteOffset", "0,0"),
            data.Attr("spriteOverlay"),
            data.Attr("spriteOverlayOffset"),
            data.Int("depth", 100),
            data.Bool("killPlayerOnDestroy"),
            data.Bool("slowsPlayerDown")
        ){}

        public CustomHoldableBasic(
            Vector2 position,
            string _spriteDirectory, string _spriteOffset, string _spriteOverlay, string _spriteOverlayOffset,
            int _depth, bool _killPlayerOnDestroy, bool _slowsPlayerDown 
        ) : base(position)
        {
            Depth = _depth;
            Collider = new Hitbox(8f, 10f, -4f, 2f); /* This is the collider size for "objects/resortclutter/yellow_14" */
            Add(_holdableSprite = new Image(GFX.Game[_spriteDirectory]));
            string[] spriteOs = _spriteOffset.Split(',');
            int spriteOs1 = Convert.ToInt32(spriteOs[0]);
            int spriteOs2 = Convert.ToInt32(spriteOs[1]);
            spriteDisplacement = new Vector2(_holdableSprite.Width / 2 - spriteOs1, _holdableSprite.Height / 2 - spriteOs2);
            _holdableSprite.Position -= spriteDisplacement;

            if (_spriteOverlay != "")
            {
                string[] overlay = _spriteOverlay.Split('|');
                if (_spriteOverlayOffset != ""){string[] overlayOs = _spriteOverlayOffset.Split('|');}
                int overlayInt = 0;
                foreach (string sOverlay in overlay)
                {
                    Add(_spriteOverlay_[overlayInt] = new Image(GFX.Game[sOverlay]));

                    



                    overlayDisplacement = new Vector2(_spriteOverlay_[overlayInt].Width / 2, _spriteOverlay_[overlayInt].Height / 2);
                    _spriteOverlay_[overlayInt].Position -= overlayDisplacement;
                }
            }

            Add(Hold = new Holdable(0.1f));
            Hold.PickupCollider = new Hitbox(24f, 24f, -12f, -12f);
            Hold.SlowFall = false;
            Hold.SlowRun = _slowsPlayerDown;
        }
        public override void Added(Scene scene)
        {
            base.Added(scene);
        }
        public override void Update()
        {
            base.Update();
            
        }
    }
}