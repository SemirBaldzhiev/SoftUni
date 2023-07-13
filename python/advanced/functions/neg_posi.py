def main():
    nums = list(map(int, input().split(' ')))
    negative_nums = [x for x in nums if x < 0]
    positive_nums = [x for x in nums if x > 0]
    sum_positive = sum(positive_nums)
    sum_negative = sum(negative_nums)
    print(sum_negative)
    print(sum_positive)
    if (-1)*sum_negative > sum_positive:
        print('The negatives are stronger than the positives')
    else:
        print('The positives are stronger than the negatives')
main()