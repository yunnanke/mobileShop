import type {
  ClientProfile,
  Contract,
  Device,
  EmployeePerformance,
  Promotion,
  Repair,
  SaleSnapshot,
  Tariff
} from "../types/domain";

export const devices: Device[] = [
  {
    id: 1,
    model: "Galaxy S25",
    manufacturer: "Samsung",
    category: "Смартфоны",
    retailPrice: 89990,
    stock: 12,
    accent: "linen"
  },
  {
    id: 2,
    model: "iPhone 16",
    manufacturer: "Apple",
    category: "Смартфоны",
    retailPrice: 109990,
    stock: 7,
    accent: "graphite"
  },
  {
    id: 3,
    model: "Redmi Note 14 Pro",
    manufacturer: "Xiaomi",
    category: "Смартфоны",
    retailPrice: 42990,
    stock: 18,
    accent: "bronze"
  }
];

export const tariffs: Tariff[] = [
  {
    id: 1,
    operator: "МТС",
    name: "Безлимитный Комфорт",
    monthlyPrice: 890,
    minutes: 1200,
    internetGb: 50,
    sms: 300
  },
  {
    id: 2,
    operator: "Билайн",
    name: "Город Онлайн",
    monthlyPrice: 690,
    minutes: 800,
    internetGb: 35,
    sms: 150
  },
  {
    id: 3,
    operator: "Теле2",
    name: "Тихий Максимум",
    monthlyPrice: 990,
    minutes: 2000,
    internetGb: 60,
    sms: 500
  }
];

export const promotions: Promotion[] = [
  {
    id: 1,
    title: "Trade-In Atelier",
    description: "Сдайте старый смартфон и получите премиальную скидку на новую модель.",
    period: "до 30 июня"
  },
  {
    id: 2,
    title: "SIM + Tariff Bundle",
    description: "Оформление нового договора с первым месяцем связи без абонентской платы.",
    period: "весь май"
  },
  {
    id: 3,
    title: "Repair Priority",
    description: "Экспресс-диагностика и приоритетная очередь на популярные ремонты.",
    period: "ежедневно"
  }
];

export const clientProfile: ClientProfile = {
  fullName: "Анастасия Романова",
  phone: "+7 (999) 555-12-44",
  email: "anastasia@demo.test",
  level: "Gold",
  bonusPoints: 1840,
  registrationDate: "14.02.2025"
};

export const clientRepairs: Repair[] = [
  {
    id: 3021,
    serialNumber: "SN-A1F2-44J2",
    issueType: "Замена дисплея",
    status: "В ремонте",
    acceptedAt: "11.05.2026"
  },
  {
    id: 2978,
    serialNumber: "SN-X9L1-20Q7",
    issueType: "Проблема с батареей",
    status: "Готов к выдаче",
    acceptedAt: "02.05.2026",
    finalCost: 6900
  }
];

export const clientContracts: Contract[] = [
  {
    id: 441,
    type: "Мобильная связь",
    startedAt: "15.03.2025",
    expiresAt: "15.03.2027",
    simNumber: "+7 900 123-45-67"
  },
  {
    id: 508,
    type: "Дополнительная SIM",
    startedAt: "09.01.2026",
    simNumber: "+7 900 555-78-01"
  }
];

export const recentSales: SaleSnapshot[] = [
  {
    id: 1,
    title: "Galaxy S25 + гарантия",
    subtitle: "Продажа #5521",
    amount: "96 890 ₽"
  },
  {
    id: 2,
    title: "iPhone 16 + аксессуары",
    subtitle: "Продажа #5520",
    amount: "118 400 ₽"
  },
  {
    id: 3,
    title: "Подключение тарифа Теле2",
    subtitle: "Договор #819",
    amount: "990 ₽"
  }
];

export const employeePerformance: EmployeePerformance[] = [
  {
    employee: "Марина Белова",
    deals: 28,
    repairs: 9,
    revenue: "1 480 000 ₽"
  },
  {
    employee: "Илья Корнеев",
    deals: 21,
    repairs: 13,
    revenue: "1 090 000 ₽"
  },
  {
    employee: "Светлана Лукина",
    deals: 18,
    repairs: 7,
    revenue: "920 000 ₽"
  }
];
