entryCount = gets.chomp.to_i
receiptDetails = Array.new(entryCount)
itemTable = {"book" => "books", "shirt" => "clothes", "dress" => "clothes", "chocolates" => "food", "chocolate bar" => "food", "wine" => "drinks"}
discountTable = {"books" => 0.05, "food" => 0.05, "drinks" => 0.05, "clothes" => 0.2, "other items" => 0.03}

originalTotalPrice = 0
discountTotalPrice = 0
totalSaving = 0

for i in 0...entryCount

  inputStr = gets.chomp
  
  # Get item name from input
  if inputStr.include?(" of ")
    itemName = inputStr.split(" at ")[0].split(" of ")[1]
  else
    itemName = inputStr.split(" at ")[0].split(/^\d+ /)[1]
  end

  # Get discount rate based on item name
  if itemTable.key?(itemName)
	itemDiscount = discountTable[itemTable[itemName]]
  else
    itemDiscount = discountTable["other items"]
  end
  
  # Get input item count and price
  itemCount = inputStr.split[0].to_f
  itemPrice = inputStr.split[-1].to_f
  
  # Price calculation
  discountPrice = itemPrice * (1 - itemDiscount)
  originalTotalPrice += itemPrice * itemCount
  discountTotalPrice += discountPrice * itemCount
  
  # Produce receipt details
  receiptDetails[i] = inputStr.gsub(/(\d+)$|(\d+\.\d+)$/, format("%.2f", discountPrice).to_s)
  
end

puts
for i in 0...entryCount
  puts receiptDetails[i]
end

totalSaving = originalTotalPrice - discountTotalPrice
printf("Total: %.2f\n", discountTotalPrice)
printf("You saved: %.2f", totalSaving)



