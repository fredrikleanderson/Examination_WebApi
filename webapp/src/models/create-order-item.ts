export class CreateOrderItem {
    orderId:number
    productId:number
    productName:string
    quantity:number

    constructor(orderId:number, productId:number, productName:string, quantity:number){
        this.orderId = orderId
        this.productId = productId
        this.productName = productName
        this.quantity = quantity
    }
}
