module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
	collisionBox::String="22,22,-11,-11", pickupCollisionBox::String="28,28,-14,-14", playerCollider::String="22,22,-11,-11",
	playerPickupOffset::String="0,0",
	killOnPickup::Bool=false, killOnCollide::Bool=false, spawnsFloating::Bool=false, playerCanCollide::Bool=false
)

const placements = Ahorn.PlacementDict(
	"Customizable Holdable (Vector Helper)" => Ahorn.EntityPlacement(
		CustomHoldable
	)
)

Ahorn.editingOrder(entity::CustomHoldable) = String["x", "y", "spriteDirectory"]

function Ahorn.selection(entity::CustomHoldable)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldable, room::Maple.Room)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	
	collisionBoxPreviewRenderString = get(entity.data, "collisionBox", "22,22,-11,-11")
	collisionBoxPreviewRender = tryparse.(Int, split(collisionBoxPreviewRenderString, ','))
	
	pickupCollisionBoxPreviewRenderString = get(entity.data, "pickupCollisionBox", "28,28,-14,-14")
	pickupCollisionBoxPreviewRender = tryparse.(Int, split(pickupCollisionBoxPreviewRenderString, ','))
	
	spriteOffsetPreviewRenderString = get(entity.data, "spriteOffset", "0,0")
	spriteOffsetPreviewRender = tryparse.(Int, split(spriteOffsetPreviewRenderString, ','))
	
	Ahorn.drawSprite(ctx, sprite, spriteOffsetPreviewRender[1], spriteOffsetPreviewRender[2])
	
	# collisionBoxPreviewRender[1]
	
	Ahorn.drawRectangle(ctx, collisionBoxPreviewRender[3], collisionBoxPreviewRender[4], collisionBoxPreviewRender[1], collisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (1.0, 0.0, 0.0, 0.5))
	
	Ahorn.drawRectangle(ctx, pickupCollisionBoxPreviewRender[3], pickupCollisionBoxPreviewRender[4], pickupCollisionBoxPreviewRender[1], pickupCollisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (0.0, 1.0, 0.0, 0.5))

end

end