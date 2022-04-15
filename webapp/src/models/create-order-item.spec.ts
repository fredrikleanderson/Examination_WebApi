import { CreateOrderItem } from './create-order-item';

describe('CreateOrderItem', () => {
  it('should create an instance', () => {
    expect(new CreateOrderItem(0, 0, "", 0)).toBeTruthy();
  });
});
