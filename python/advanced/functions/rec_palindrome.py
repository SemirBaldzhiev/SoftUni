def palindrome(string, idx):
    if idx == len(string)//2:
        return f'{string} is a palindrome'
    if string[idx] == string[len(string)-1-idx]:
        return palindrome(string, idx+1)
    else:
        return f'{string} is not a palindrome'