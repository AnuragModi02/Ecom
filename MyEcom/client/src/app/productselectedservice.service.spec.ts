import { TestBed } from '@angular/core/testing';

import { ProductselectedserviceService } from './productselectedservice.service';

describe('ProductselectedserviceService', () => {
  let service: ProductselectedserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductselectedserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
