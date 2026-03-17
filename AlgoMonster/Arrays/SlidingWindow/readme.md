

1 Longest substring without repeating characters
2 Longest repeating character replacement
3️ Minimum window substring
4️ Subarray product < K
5️ Subarrays with K distinct integers

These cover all 4 patterns.


1. Fixed Window Size

When to recognize

    The window size is exactly K.

Examples:

    Maximum sum subarray of size K

    Average of subarrays of size K

    Maximum number of vowels in substring length K


```
int windowSum = 0;

for (int right = 0; right < nums.Length; right++)
{
    windowSum += nums[right];

    if (right >= k - 1)
    {
        // use the window
        result = Math.Max(result, windowSum);

        windowSum -= nums[right - k + 1];
    }
}
```

2. Longest Valid Window

When to recognize

The question asks:

    maximum length substring / subarray satisfying condition

Examples:

    Longest substring without repeating characters

    Longest repeating character replacement

    Longest subarray with sum ≤ K

```
int left = 0;

for (int right = 0; right < nums.Length; right++)
{
    add(nums[right]);

    while(window invalid)
    {
        remove(nums[left]);
        left++;
    }

    maxLen = Math.Max(maxLen, right - left + 1);
}
```


3. Count Valid Windows

When to recognize

The question says:

    count number of subarrays/substrings

    AND the constraint is monotonic.

Examples:

    Subarray product < K

    Subarrays with at most K distinct

    Substrings with at most K distinct

```
int left = 0;

for (int right = 0; right < nums.Length; right++)
{
    add nums[right] to window

    while(window invalid)
    {
        remove(nums[left]);
        left++;
    }

    res += right - left + 1;
}
```

4. Minimum Window

When to recognize

The question asks:

    smallest substring / subarray satisfying requirement

Examples:

    Minimum window substring

    Smallest subarray ≥ target sum

```
for (int right = 0; right < s.Length; right++)
{
    add(s[right]);

    while(window valid)
    {
        minLen = Math.Min(minLen, right - left + 1);

        remove(s[left]);
        left++;
    }
}
```


Sliding window doesn't work for arrays that contains negatives, zeros in addition to positive numbers

e.g.
560. Subarray Sum Equals K
https://leetcode.com/problems/subarray-sum-equals-k/description