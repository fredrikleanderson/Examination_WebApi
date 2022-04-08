export class UpdateProduct {
    name?: string;
    description?: string;
    price?: number;
    categoryName?: string;

    constructor(name:string, description:string, price:number, categoryName:string){
        this.name = name
        this.description = description
        this.price = price
        this.categoryName = categoryName
    }

}
