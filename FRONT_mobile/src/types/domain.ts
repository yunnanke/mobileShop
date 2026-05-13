export type Device = {
  id: number;
  model: string;
  manufacturer: string;
  category: string;
  retailPrice: number;
  stock: number;
  accent: string;
};

export type Tariff = {
  id: number;
  operator: string;
  name: string;
  monthlyPrice: number;
  minutes: number;
  internetGb: number;
  sms: number;
};

export type Promotion = {
  id: number;
  title: string;
  description: string;
  period: string;
};

export type ClientProfile = {
  fullName: string;
  phone: string;
  email: string;
  level: string;
  bonusPoints: number;
  registrationDate: string;
};

export type Repair = {
  id: number;
  serialNumber: string;
  issueType: string;
  status: string;
  acceptedAt: string;
  finalCost?: number;
};

export type Contract = {
  id: number;
  type: string;
  startedAt: string;
  expiresAt?: string;
  simNumber: string;
};

export type SaleSnapshot = {
  id: number;
  title: string;
  subtitle: string;
  amount: string;
};

export type EmployeePerformance = {
  employee: string;
  deals: number;
  repairs: number;
  revenue: string;
};
