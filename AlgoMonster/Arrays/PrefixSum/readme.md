🧩 What Prefix Sum Really Is

A way to represent every subarray sum ending at index i using cumulative history.

Core idea
prefix[i] = sum of elements from 0 → i
subarray(i+1 → j) = prefix[j] - prefix[i]


This lets us reason about subarrays without shrinking windows.