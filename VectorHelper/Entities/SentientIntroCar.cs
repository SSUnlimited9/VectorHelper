using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [CustomEntity("VectorHelper/SentientIntroCar")]
    public class SentientIntroCar : Actor
    {
        private float speedMultiplier, stunSpeed;
        private bool active, invincible, xrayVision, onlyDetectOnYAxis, idleRoam, silent, facingLeft;
        private float detectionRangeMin, detectionRangeMax;
        private float chaseDelay, chaseToIdleDelay;
        private int yAxisDetectionRangeLow, yAxisDetectionRangeHigh;
        private float stunDurationMin, stunDurationMax;
        private Color idleColor, chaseColor, stunColor, notActiveColor;
        private Image carSprite, wheelSprite, lightsSprite;
        private Hitbox mainBase, centerBox, lowerBase, backBox;
        private Hitbox playerPlatformA, playerPlatformB;
        private Circle detectionRangeSmall, detectionRangeLarge;
        private Hitbox detectionRangeYMin, detectionRangeYMax;
        private Collider playerPlatform, detectionRangeA, detectionRangeB;
        private ColliderList mainCar, playerPlatforms;


        public SentientIntroCar(EntityData data, Vector2 offset, EntityID id) : base(data.Position + offset)
        {
            Depth = 10;
            speedMultiplier = data.Float("speedMultiplier", 1f); stunSpeed = data.Float("stunSpeed", 1f);
            active = data.Bool("active", true); invincible = data.Bool("invincible", false); xrayVision = data.Bool("xrayVision", false);
            onlyDetectOnYAxis = data.Bool("onlyDetectOnYAxis", false); idleRoam = data.Bool("idleRoam", false);
            silent = data.Bool("silent", false); facingLeft = data.Bool("left", false);
            detectionRangeMin = data.Float("detectionRangeMin", 350f); detectionRangeMax = data.Float("detectionRangeMax", 415f);
            chaseDelay = data.Float("chaseDelay", 1.5f); chaseToIdleDelay = data.Float("chaseToIdleDelay", 2f);
            yAxisDetectionRangeLow = data.Int("yAxisDetectionRangeLow", -26); yAxisDetectionRangeHigh = data.Int("yAxisDetectionRangeHigh", 26);
            stunDurationMin = data.Float("stunDurationMin", 5f); stunDurationMax = data.Float("stunDurationMax", 10f);
            idleColor = Calc.HexToColor(data.Attr("idleColor", "ffffff")); chaseColor = Calc.HexToColor(data.Attr("chaseColor", "ff0000"));
            stunColor = Calc.HexToColor(data.Attr("stunColor", "353535"));
            if (stunColor == Calc.HexToColor("353535"))
            { notActiveColor = Calc.HexToColor("6a6a6a"); } else { notActiveColor = Calc.HexToColor("353535"); }

            Add(wheelSprite = new Image(GFX.Game["scenery/car/wheels"])); wheelSprite.Origin = new Vector2(wheelSprite.Width / 2f, wheelSprite.Height);            
            Add(carSprite = new Image(GFX.Game["scenery/car/body"])); carSprite.Origin = new Vector2(carSprite.Width / 2f, carSprite.Height);
            Add(lightsSprite = new Image(GFX.Game["VectorHelper/introcarlights"])); lightsSprite.Origin = new Vector2(lightsSprite.Width / 2f, lightsSprite.Height);

            mainBase = new Hitbox(45f, 4f, -21f, -7f); lowerBase = new Hitbox(35f, 3f, -19f, -3f);
            centerBox = new Hitbox(23f, 5f, -15f, -13f); backBox = new Hitbox(3f, 3f, -19f, -11f);
            playerPlatformA = new Hitbox(25f, 3f, -15f, -17f); playerPlatformB = new Hitbox(16f, 3f, 8f, -11f);

            mainCar = new ColliderList(new Collider[] { mainBase, lowerBase, centerBox, backBox });
            playerPlatforms = new ColliderList(new Collider[] { playerPlatformA, playerPlatformB });
            Collider = mainCar; playerPlatform = playerPlatforms;

            if (yAxisDetectionRangeLow == 0) { yAxisDetectionRangeLow = -1; }
            if (yAxisDetectionRangeHigh == 0) { yAxisDetectionRangeHigh = 1; }

            detectionRangeSmall = new Circle(detectionRangeMin, 1f, -9f); detectionRangeLarge = new Circle(detectionRangeMax, 1f, -9f);
            detectionRangeYMin = new Hitbox( detectionRangeMin, (yAxisDetectionRangeLow * -1f) + yAxisDetectionRangeHigh, 24f, -11f - yAxisDetectionRangeHigh);

            detectionRangeYMax = new Hitbox( detectionRangeMax, (yAxisDetectionRangeLow * -1f) + yAxisDetectionRangeHigh, 24f, -11f - yAxisDetectionRangeHigh);
            if (onlyDetectOnYAxis) { detectionRangeA = detectionRangeYMin; detectionRangeB = detectionRangeYMax; } else { detectionRangeA = detectionRangeSmall; detectionRangeB = detectionRangeLarge; }
            //Add(new PlayerCollider(new Action<Player>(OnAttack), Collider, Collider));
            //Add(new PlayerCollider(new Action<Player>(OnPlayer), playerPlatform));
            //Add(new PlayerCollider(new Action<Player>(OnDetectMax), detectionRangeB));
            //Add(new PlayerCollider(new Action<Player>(OnDetectMin), detectionRangeA));
        
        }
        /*
            The base collider is the kill box (Red)
            The playerPlatform collider is for the players interactions (Such as stunning the car) (Green)
            detectionRangeA is the collider/detection zone that will guranatee triggering the car (Pink/Hot Pink)
            detectionRangeB is the collider/detection zone that will have a chance of triggering the car (Purple)
        */
        public override void Update()
        {
            base.Update();
            carDirection(facingLeft);
            
        }

        private void carDirection(bool left)
        {
            if (left)
            {
                wheelSprite.Scale.X = -1; wheelSprite.Position.X = 3f; carSprite.Scale.X = -1; carSprite.Position.X = 3f; lightsSprite.Scale.X = -1; lightsSprite.Position.X = 3f;
                lowerBase.Position.X = -13f; centerBox.Position.X = -5f; backBox.Position.X = 19f; playerPlatformA.Position.X = -7f; playerPlatformB.Position.X = -21f;
                detectionRangeSmall.Position.X = 2f; detectionRangeLarge.Position.X = 2f;
                detectionRangeYMin.Position.X = -21f - detectionRangeMin; detectionRangeYMax.Position.X = -21f - detectionRangeMax;

            } else
            {
                wheelSprite.Scale.X = 1; wheelSprite.Position.X = 0f; carSprite.Scale.X = 1; carSprite.Position.X = 0f; lightsSprite.Scale.X = 1; lightsSprite.Position.X = 0f;
                lowerBase.Position.X = -19f; centerBox.Position.X = -15f; backBox.Position.X = -19f; playerPlatformA.Position.X = -15f; playerPlatformB.Position.X = 8f;
                detectionRangeSmall.Position.X = 1f; detectionRangeLarge.Position.X = 1f;
                detectionRangeYMin.Position.X = 24f; detectionRangeYMax.Position.X = 24f;
            }
        }

        public override void DebugRender(Camera camera)
        {
            Collider collider = base.Collider;
            base.Collider.Render(camera);
            base.Collider = playerPlatform;
            playerPlatform.Render(camera, Color.Lime);
            base.Collider = detectionRangeB;
            detectionRangeB.Render(camera, Color.Purple);
            base.Collider = detectionRangeA;
            detectionRangeA.Render(camera, Color.HotPink);
            base.Collider = collider;
        }
    }
}