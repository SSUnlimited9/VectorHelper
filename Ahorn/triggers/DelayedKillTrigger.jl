module VectorHelperDelayedKillTrigger

using ..Ahorn, Maple

@mapdef Trigger "VectorHelper/DelayedKillTrigger" DelayedKillTrigger(
	x::Integer, y::Integer, width::Integer=Maple.defaultTriggerWidth, height::Integer=Maple.defaultTriggerHeight,
	delay::Number=1.0, resetDelayOnLeave::Bool=true, resetDelayIfInvincible::Bool=false,
	ignoreInvincibleAssist::Bool=false, addToDeathCount::Bool=false
)

const placements = Ahorn.PlacementDict(
	"Kill Trigger (Delayed) (Vector Helper)" => Ahorn.EntityPlacement(
		DelayedKillTrigger,
		"rectangle"
	)
)

Ahorn.editingOrder(entity::DelayedKillTrigger) = String[
	"x", "y",
	"width", "height",
	"delay", "ignoreInvincibleAssist", "addToDeathCount",
	"resetDelayOnLeave", "resetDelayIfInvincible"	
]

end