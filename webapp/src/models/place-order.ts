export class PlaceOrder {
    userId?: number
    orderReceived?: Date
    orderStatus?: string

    constructor(userId: number, orderReceived: Date, orderStatus:string){
        this.userId = userId
        this.orderReceived = orderReceived
        this.orderStatus = orderStatus
    }
}