# File written by SSUnlimited

module VectiorHelperSentientIntroCar

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/SentientIntroCar" SentientIntroCar(
	x::Integer, y::Integer,
	speedMultiplier::Number=1.0, stunSpeed::Number=0.0,
	active::Bool=true, invincible::Bool=false, xrayVision::Bool=false, onlyDetectOnYAxis::Bool=false,
	idleRoam::Bool=false, silent::Bool=false, left::Bool=false,
	detectionRangeMin::Number=350.0, detectionRangeMax::Number=415.0,
	chaseDelay::Number=1.5, chaseToIdleDelay::Number=2.0,
	yAxisDetectionRangeLow::Integer=-26, yAxisDetectionRangeHigh::Integer=26,
	idleColor::String="ffffff", chaseColor::String="ff0000", stunColor::String="353535",
	stunDurationMin::Number=5.0, stunDurationMax::Number=10.0,
	activateSound::String="", deactivateSound::String="", idleSound::String="", moveSound::String="",
	hitPlayerSound::String="", stunSound::String="", crashSound::String="",
	fallSound::String="", hardFallSound::String="", deathSound::String="",
	chaseBgm::String="", proximityBgm::String=""
)

const placements = Ahorn.PlacementDict(
	"Sentient Intro Car (Vector Helper)" => Ahorn.EntityPlacement(
		SentientIntroCar
	)
)

Ahorn.editingOrder(entity::SentientIntroCar) = String[
	"x", "y",
	"speedMultiplier", "stunSpeed",
	"detectionRangeMin", "detectionRangeMax",
	"yAxisDetectionRangeLow", "yAxisDetectionRangeHigh",
	"activateSound", "deactivateSound",
	"idleSound", "moveSound",
	"hitPlayerSound", "stunSound",
	"fallSound", "hardFallSound",
	"crashSound", "deathSound",
	"proximityBgm", "chaseBgm",
	"stunDurationMin", "stunDurationMax",
	"chaseDelay", "chaseToIdleDelay",
	"idleColor", "chaseColor",
	"stunColor", "silent", "active",
	"idleRoam", "invincible", "xrayVision", "onlyDetectOnYAxis",
	"left"
]

const sprite = "scenery/car/body"
const wheelSprite = "scenery/car/wheels"

function Ahorn.selection(entity::SentientIntroCar)
	x, y = Ahorn.position(entity)
	isLeft = get(entity, "left", false) ? -1 : 1
	oX = get(entity, "left", false) ? x + 3 : x

	carMain = Ahorn.Rectangle[
		Ahorn.getSpriteRectangle(sprite, oX, y, jx = .5, jy = 1.0, sx = isLeft)
		Ahorn.getSpriteRectangle(wheelSprite, oX, y, jx = .5, jy = 1.0, sx = isLeft)
	]

	return Ahorn.coverRectangles(carMain)
end

function Ahorn.renderAbs(ctx::Ahorn.Cairo.CairoContext, entity::SentientIntroCar)
	x, y = Ahorn.position(entity)
	isLeft = get(entity, "left", false) ? -1 : 1
	oX = get(entity, "left", false) ? x + 3 : x

	Ahorn.drawSprite(ctx, wheelSprite, oX, y, jx = 0.5, jy = 1.0, sx = isLeft)
	Ahorn.drawSprite(ctx, sprite, oX, y, jx = 0.5, jy = 1.0, sx = isLeft)
end

end