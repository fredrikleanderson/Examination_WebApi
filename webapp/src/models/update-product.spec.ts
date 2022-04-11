import { UpdateProduct } from './update-product';

describe('UpdateProduct', () => {
  it('should create an instance', () => {
    expect(new UpdateProduct("", "", 0, "", 0)).toBeTruthy();
  });
});
