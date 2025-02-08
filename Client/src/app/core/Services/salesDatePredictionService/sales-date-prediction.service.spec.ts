import { TestBed } from '@angular/core/testing';

import { SalesDatePredictionService } from './sales-date-prediction.service';

describe('SalesDatePredictionService', () => {
  let service: SalesDatePredictionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalesDatePredictionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
