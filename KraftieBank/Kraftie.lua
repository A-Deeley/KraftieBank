SLASH_KRAFTIE1 = "/kb"
SLASH_KRAFTIE2 = "/kraftie"
SLASH_KRAFTIE3 = "/kraftiebank"

SlashCmdList.KRAFTIE = function(msg, editBox)
    print("Thanks for testing Kraftie Bank!")
end

-- Register to BANKFRAME_OPENED event to scan for bank items
local eventListener = CreateFrame("Frame")

function eventListener:OnEvent(event, ...)
    self[event](self, event, ...)
end

function eventListener:BANKFRAME_OPENED(event)
    purchasedBankSlots, full = GetNumBankSlots()
    KraftieBankContents = {}

    for base_bank_slot=1, 24 do
        local _,itemCount,_,itemQuality,_,_,itemLink,_,_,itemId = GetContainerItemInfo(-1, base_bank_slot)
        if (itemCount) then
            table.insert(KraftieBankContents, { count = itemCount, id = itemId, quality = itemQuality, link = itemLink })
        end
    end

    if (purchasedBankSlots > 0) then
        for bank_container_index=NUM_BAG_SLOTS+1,NUM_BAG_SLOTS+1+purchasedBankSlots do
            for bank_container_slot=1,GetContainerNumSlots(bank_container_index) do
                local _,itemCount,_,itemQuality,_,_,itemLink,_,_,itemId = GetContainerItemInfo(bank_container_index, bank_container_slot)
                if (itemCount) then
                    table.insert(KraftieBankContents, { count = itemCount, id = itemId, quality = itemQuality, link = itemLink })
                end
            end
        end
    end

    for _,item in ipairs(KraftieBankContents) do
        print(item.count .. "x " .. item.id)
    end
    
end

eventListener:RegisterEvent("BANKFRAME_OPENED")
eventListener:SetScript("OnEvent", eventListener.OnEvent)
-- -- Item Info Model
-- function ItemInfo:new (o,itemLink, count)
--     o = o or {}
--     setmetatable(o, self)
--     self.__index = self
--     self.itemLink = itemLink
--     self.count = count or 0

--     return o
-- end