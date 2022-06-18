import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateQrCodeComponent } from './create-qr-code.component';

describe('CreateQrCodeComponent', () => {
  let component: CreateQrCodeComponent;
  let fixture: ComponentFixture<CreateQrCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateQrCodeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateQrCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
