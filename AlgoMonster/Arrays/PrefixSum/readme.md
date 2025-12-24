🧩 What Prefix Sum Really Is

A way to represent every subarray sum ending at index i using cumulative history.

Core idea
prefix[i] = sum of elements from 0 → i
subarray(i+1 → j) = prefix[j] - prefix[i]


This lets us reason about subarrays without shrinking windows.

📌 Prefix Sum Patterns (Just 3 You Need)

🔹 Pattern 1: Prefix Sum + HashMap (COUNT)

	“How many subarrays…”

		count of subarrays with sum = K

		negatives allowed

		order matters

	👉 result is a count

	Pattern:
	`
	map[0] = 1
	runningSum = 0
	count = 0

	for num in nums:
		runningSum += num
		if (runningSum - K) in map:
			count += map[runningSum - K]
		map[runningSum]++

	`

🔹 Pattern 2: Prefix Sum + HashMap (LONGEST LENGTH) ⭐

	“Longest / max length subarray…”

		longest contiguous subarray

		condition depends on difference

		negatives allowed

		store first occurrence of prefix sum

	👉 result is a length

	Pattern:
	`
	map[0] = -1
	runningSum = 0

	for i:
		runningSum += nums[i]
		if (runningSum - K) exists:
			length = i - map[runningSum - K]
		if runningSum not in map:
			map[runningSum] = i
	`

	

🔹 Pattern 3: Prefix Sum + Modulo

	Divisibility / cycles

		sum % K == 0

		same remainder trick

	Pattern:
	`
	(a - b) % k = 0 → same remainder
	`