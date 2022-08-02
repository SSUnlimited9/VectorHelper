--VectorHelper Delayed Kill trigger (Loenn Integration)
--Written by KthVeg

local DelayedKillTrigger = {}

DelayedKillTrigger.name = "VectorHelper/DelayedKillTrigger"
DelayedKillTrigger.fieldOrder = {
    "x","y","width","height",
    "delay","ignoreInvincibleAssist",
    "addToDeathCount","resetDelayOnLeave"
}
DelayedKillTrigger.placements = {
    {
        name = "Delay Kill",
        data = {
            delay = 1.0,
            resetDelayOnLeave = true,
            resetDelayIfInvincible = false,
            addToDeathCount = false,
            ignoreInvincibleAssist = false
        }
    }
}

return DelayedKillTrigger
