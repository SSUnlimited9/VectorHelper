# VectorHelper Customizable Holdable Entities
# File written by SSUnlimited

module VectorHelperCustomHoldable
using ..Ahorn, Maple

@mapdef Entity "VectorHelper/CustomHoldableBasic" CustomHoldableBasic(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
	spriteOverlay::String="", spriteOverlayOffset="",
	depth::Integer=100, killPlayerOnDestroy::Bool=false, slowsPlayerDown::Bool=true
)

const placements = Ahorn.PlacementDict(
	"Custom Holdable (Basic) (Vector Helper)" => Ahorn.EntityPlacement(
		CustomHoldableBasic
	)
)

Ahorn.editingOrder(entity::CustomHoldableBasic) = String["x", "y", "spriteDirectory", "spriteOffset", "spriteOverlay", "spriteOverlayOffset","depth", "killPlayerOnDestroy", "slowsPlayerDown"]

function Ahorn.selection(entity::CustomHoldableBasic)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")

	return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldableBasic)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	spriteOffsetPreviewRender = tryparse.(Int, split(get(entity.data, "spriteOffset", "0,0"), ','))

	spriteOverlayPreviewRender = split(get(entity.data, "spriteOverlay", ""), '|')
	spriteOverlayOffsetPreviewRender = split(get(entity.data, "spriteOverlayOffset", ""), '|')

	if isassigned(spriteOffsetPreviewRender, 1) && isassigned(spriteOffsetPreviewRender, 2)
		if isa(spriteOffsetPreviewRender[1], Int) && isa(spriteOffsetPreviewRender[2], Int)
			Ahorn.drawSprite(ctx, sprite, spriteOffsetPreviewRender[1], spriteOffsetPreviewRender[2])
		else
			Ahorn.drawSprite(ctx, sprite, 0, 0)
		end
	else
		Ahorn.drawSprite(ctx, sprite, 0, 0)
	end

	overlayInt = 1
	for overlay in spriteOverlayPreviewRender
		if overlay != ""
			overlayRender = String(overlay)
			
			if isassigned(spriteOverlayOffsetPreviewRender, overlayInt)
				overlayOffset = tryparse.(Int, split(spriteOverlayOffsetPreviewRender[overlayInt], ','))
				if isassigned(overlayOffset, 1) && isassigned(overlayOffset, 2)
					if isa(overlayOffset[1], Int) && isa(overlayOffset[2], Int)
						Ahorn.drawSprite(ctx, overlayRender, overlayOffset[1], overlayOffset[2])
					else
						Ahorn.drawSprite(ctx, overlayRender, 0, 0)
					end
				else
					Ahorn.drawSprite(ctx, overlayRender, 0, 0)
				end
			else
				Ahorn.drawSprite(ctx, overlayRender, 0, 0)
			end
		end
		overlayInt += 1
	end
end

end

#@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(
#	x::Integer, y::Integer,
#	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
#	collisionBox::String="22,22,-11,-11", pickupCollisionBox::String="28,28,-14,-14", playerCollider::String="22,22,-11,-11",
#	playerPickupOffset::String="0,0",
#	killOnPickup::Bool=false, killOnCollide::Bool=false, spawnsFloating::Bool=false, playerCanCollide::Bool=false
#)






# IGNORE THIS AREA
#function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldable, room::Maple.Room)
	#x = Int(get(entity.data, "x", 0))
	#y = Int(get(entity.data, "y", 0))
	#sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	
	#collisionBoxPreviewRenderString = get(entity.data, "collisionBox", "22,22,-11,-11")
	#collisionBoxPreviewRender = tryparse.(Int, split(collisionBoxPreviewRenderString, ','))
	
	#pickupCollisionBoxPreviewRenderString = get(entity.data, "pickupCollisionBox", "28,28,-14,-14")
	#pickupCollisionBoxPreviewRender = tryparse.(Int, split(pickupCollisionBoxPreviewRenderString, ','))
	
	#spriteOffsetPreviewRenderString = get(entity.data, "spriteOffset", "0,0")
	#spriteOffsetPreviewRender = tryparse.(Int, split(spriteOffsetPreviewRenderString, ','))
	
	#Ahorn.drawSprite(ctx, sprite, spriteOffsetPreviewRender[1], spriteOffsetPreviewRender[2])
	
	#Ahorn.drawRectangle(ctx, collisionBoxPreviewRender[3], collisionBoxPreviewRender[4], collisionBoxPreviewRender[1], collisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (1.0, 0.0, 0.0, 0.5))
	
	#Ahorn.drawRectangle(ctx, pickupCollisionBoxPreviewRender[3], pickupCollisionBoxPreviewRender[4], pickupCollisionBoxPreviewRender[1], pickupCollisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (0.0, 1.0, 0.0, 0.5))

#end