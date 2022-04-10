export class UpdateProduct {
    name?: string;
    description?: string;
    price?: number;
    categoryName?: string;
    quantity?: number;

    constructor(name:string, description:string, price:number, categoryName:string, quantity: number){
        this.name = name
        this.description = description
        this.price = price
        this.categoryName = categoryName
        this.quantity = quantity
    }

}
