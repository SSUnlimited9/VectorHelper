module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(x::Integer, y::Integer, spriteDirectory::String="objects/resortclutter/yellow_14", collisionBox::String="8,10,-4,-10", pickupCollisionBox::String="24,24,-12,-12", killOnPickup::Bool=false, killOnCollide::Bool=false, spawnsFloating::Bool=false)

const placements = Ahorn.PlacementDict(
	"Customizable Holdable (Vector Helper)" => Ahorn.EntityPlacement(
		CustomHoldable
	)
)

Ahorn.editingOrder(entity::CustomHoldable) = String["x", "y", "spriteDirectory", "collisionBox", "pickupCollisionBox"]

function Ahorn.selection(entity::CustomHoldable)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldable, room::Maple.Room)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	
	collisionBoxPreviewRenderString = get(entity.data, "collisionBox", "8,10,-4,-10")
	collisionBoxPreviewRender = split(collisionBoxPreviewRenderString, ',')
	
	collisionBoxRenderTest = Int(get(collisionBoxPreviewRender[1]))
	
	#pickupCollisionBoxPreviewRenderString = get(entity.data, "pickupCollisionBox", "24,24,-12,-12")
	#pickupCollisionBoxPreviewRender = Int, split(pickupCollisionBoxPreviewRenderString, ',', 4)
	
	Ahorn.drawSprite(ctx, sprite, 0, 0)
	
	# collisionBoxPreviewRender[1]
	
	Ahorn.drawRectangle(ctx, 0, 0, collisionBoxRenderTest, 8, (0.0, 0.0, 0.0, 0.0), (1.0, 0.0, 0.0, 0.5))
	
	Ahorn.drawRectangle(ctx, 1, 0 - 1, 32, 32, (0.0, 0.0, 0.0, 0.0), (0.0, 1.0, 0.0, 0.5))
end

end