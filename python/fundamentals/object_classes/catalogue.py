class Catalogue:
    products = []
    def __init__(self, name: str):
        self.name = name

    def add_product(self, product_name: str) -> None:
        self.products.append(product_name)
    def get_by_letter(self, first_letter: str) -> list:
        return [p for p in self.products if p.startswith(first_letter) == True]
    def __repr__(self) -> str:
        sorted_prods = sorted(self.products)
        res = f'Items in the {self.name} catalogue:\n'
        res += '\n'.join(sorted_prods)
        return res
