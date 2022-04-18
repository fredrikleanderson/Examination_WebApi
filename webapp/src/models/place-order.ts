export class PlaceOrder {
    userId?: number
    orderStatus?: string

    constructor(userId: number, orderStatus:string){
        this.userId = userId
        this.orderStatus = orderStatus
    }
}