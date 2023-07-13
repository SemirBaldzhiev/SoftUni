def even_odd_filter(odd = None, even = None):
    dic = dict()
    if odd:
        dic["odd"] = list(filter(lambda x: x%2!=0, odd))
    if even:
        dic["even"] = list(filter(lambda x: x%2==0, even))
    l = list(dic.items())
    l.sort(key=lambda x: len(x[1]), reverse=True)
    return dict(l)