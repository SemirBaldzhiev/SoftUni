class Inventory:

    def __init__(self, cap: int):
        self.__capacity = cap
        self.items = []

    def add_item(self, item: str):
        if len(self.items) < self.__capacity:
            self.items.append(item)
        else:
            return 'not enough room in the inventory'
    def get_capacity(self) -> int:
        return self.__capacity
    def __repr__(self) -> str:
        res = ', '.join(self.items)
        return f'Items: {res}.\nCapacity left: {self.__capacity - len(self.items)}'
