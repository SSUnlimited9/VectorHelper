module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(x::Integer, y::Integer, spriteDirectory::String="testString")

const placements = Ahorn.PlacementDict(
	"Customizable Holdable (Vector Helper)" => Ahorn.EntityPlacement(
		CustomHoldable
	)
)

end