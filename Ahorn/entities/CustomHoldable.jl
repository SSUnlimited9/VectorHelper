# File written by SSUnlimited

module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/BasicCustomHoldable" BasicCustomHoldable(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
	visualDepth::Integer=100, linkedToPlayer::Bool=false, slowsPlayerDown::Bool=false,
	spawnId::String="", interactionId::String=""
)

const placements = Ahorn.PlacementDict(
	"Custom Holdable (Basic) (Vector Helper)" => Ahorn.EntityPlacement(
		BasicCustomHoldable
	)
)

Ahorn.editingOrder(entity::BasicCustomHoldable) = String[
	"x", "y",
	"spriteDirectory", "spriteOffset",
	"visualDepth", "linkedToPlayer", "slowsPlayerDown",
	"spawnId", "interactionId"]

function Ahorn.selection(entity::BasicCustomHoldable)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::BasicCustomHoldable)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	offset = tryparse.(Int, split(get(entity.data, "spriteOffset", "0,0"), ','))

	try
		Ahorn.renderSprite(ctx, sprite, offset[1], offset[2])
	catch
		Ahorn.renderSprite(ctx, sprite, 0, 0)
	end
end

end