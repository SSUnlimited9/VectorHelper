# File written by SSUnlimited

module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/BasicCustomHoldable" BasicCustomHoldable(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
	visualDepth::String="100,-100", linkedToPlayer::Bool=false, slowsPlayerDown::Bool=false,
	spawnsFloating::Bool=false,
	spawnId::String="", interactionId::String="", modifierId::String=""
)

@mapdef Entity "VectorHelper/BasicCustomHoldableAnimated" BasicCustomHoldableAnimated(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
	animationConfig::String="",
	visualDepth::String="100,-100", linkedToPlayer::Bool=false, slowsPlayerDown::Bool=false,
	spawnsFloating::Bool=false,
	spawnId::String="", interactionId::String="", modifierId::String=""
)

const placements = Ahorn.PlacementDict(
	"Custom Holdable (Basic) (Vector Helper)" => Ahorn.EntityPlacement(
		BasicCustomHoldable
	),
	"Custom Holdable (Basic) (Animated) (Vector Helper)" => Ahorn.EntityPlacement(
		BasicCustomHoldableAnimated
	)
)

Ahorn.editingOrder(entity::BasicCustomHoldable) = String[
	"x", "y",
	"spriteDirectory", "spriteOffset",
	"visualDepth", "linkedToPlayer", "slowsPlayerDown",
	"spawnId", "spawnsFloating",
	"interactionId", "modifierId"
]

Ahorn.editingOrder(entity::BasicCustomHoldableAnimated) = String[
	"x", "y",
	"spriteDirectory", "spriteOffset",
	"animationConfig", "visualDepth"
]

function Ahorn.selection(entity::BasicCustomHoldable)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.selection(entity::BasicCustomHoldableAnimated)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::BasicCustomHoldable)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	offset = tryparse.(Int, split(get(entity.data, "spriteOffset", "0,0"), ","))
	try
		Ahorn.drawSprite(ctx, sprite, offset[1], offset[2])
	catch
		Ahorn.drawSprite(ctx, sprite, 0, 0)
		println("Offset contains invalid data: " + get(entity.data, "spriteOffset", "0,0"))
	end
end

end