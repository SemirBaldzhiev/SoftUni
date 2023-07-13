def even_odd(*args):
    func_table = {
        "even": lambda x: x % 2 == 0,
        "odd":lambda x: x % 2 != 0
    }
    return list(filter(func_table[args[-1]], args[:-1]))