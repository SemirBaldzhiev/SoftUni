class Vehicle:
    __owner = None
    def __init__(self, type: str, model: str, price: int):
        self.type = type
        self.model = model
        self.price = price

    def buy(self, money: int, owner: str):
        if self.__owner != None:
            return 'Car already sold'

        if money >= self.price:
            self.__owner = owner
            return f'Successfully boughta {self.type}. Change: {(money - self.price):.2f}'
        else:
            return 'Sorry, not enough money'

    def sell(self):
        if self.__owner != None:
            self.__owner = None
        else:
            print('Vehicle has no owner')

    def __repr__(self):
        if self.__owner != None:
            return f'{self.model} {self.type} is owned by: {self.__owner}'
        else:
            return f'{self.model} {self.type} is on sale: {self.price}'
