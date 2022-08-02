--VectorHelper Delayed Kill trigger (Loenn Integration)
--Written by KthVeg

local DelayKillTrigger = {}

DelayKillTrigger.name = "VectorHelper/DelayedKillTrigger"
DelayKillTrigger.fieldOrder = {
    "x", "y",
    "width", "height",
    "delay", "ignoreInvincibleAssist",
    "addToDeathCount", "resetDelayOnLeave"
}
DelayKillTrigger.placements = {
    {
        name = "Kill Trigger (Delayed)",
        data = {
            delay = 1.0,
            resetDelayOnLeave = true,
            resetDelayIfInvincible = false,
            addToDeathCount = false,
            ignoreInvincibleAssist = false
        }
    }
}

return DelayKillTrigger