module VectorHelperDelayKillTrigger
using ..Ahorn, Maple

@mapdef Trigger "VectorHelper/DelayKillTrigger" DelayKillTrigger(
	x::Integer, y::Integer,
	width::Integer=Maple.defaultTriggerWidth, height::Integer=Maple.defaultTriggerHeight,
	delay::Number=1.0, ifFlag::String="", notFlag="", flagAfterDeath="",
	ignoreInvincibleAssist::Bool=false, registerDeathInSave::Bool=false
)

const placements = Ahorn.PlacementDict(
	"Kill Trigger (Delay) (Vector Helper)" => Ahorn.EntityPlacement(
		DelayKillTrigger,
		"rectangle"
	)
)

end