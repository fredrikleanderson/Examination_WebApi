import { PlaceOrder } from './place-order';

describe('PlaceOrder', () => {
  it('should create an instance', () => {
    expect(new PlaceOrder(0, new Date(), "Received")).toBeTruthy();
  });
});
