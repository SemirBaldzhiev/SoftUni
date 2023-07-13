def main():
    numbers = list(map(float, input().split(" ")))
    nums_cnt = dict()

    for n in numbers:
        if n in nums_cnt:
            nums_cnt[n]+=1
        else:
            nums_cnt[n] = 1
    for key in nums_cnt:
        print(f"{key:.1f} - {nums_cnt[key]} times")
main()