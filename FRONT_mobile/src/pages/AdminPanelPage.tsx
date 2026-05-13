import { SectionTitle } from "../components/SectionTitle";
import { devices, employeePerformance, tariffs } from "../data/mockData";

export function AdminPanelPage() {
  return (
    <div className="admin-layout">
      <aside className="admin-side">
        <p>Меню</p>
        <a href="#devices">Устройства</a>
        <a href="#tariffs">Тарифы</a>
        <a href="#employees">Сотрудники</a>
        <a href="#reports">Отчёты</a>
      </aside>

      <div className="page-stack">
        <section className="dashboard-hero">
          <SectionTitle
            eyebrow="Администратор"
            title="CRUD-панель"
            description="Здесь заложена структура под таблицы, массовые действия, редактирование сущностей и отчёты. Пока без реальных API-вызовов."
          />
        </section>

        <section id="devices" className="dashboard-card">
          <h3>Устройства</h3>
          <table className="data-table">
            <thead>
              <tr>
                <th>Модель</th>
                <th>Производитель</th>
                <th>Категория</th>
                <th>Цена</th>
                <th>Остаток</th>
              </tr>
            </thead>
            <tbody>
              {devices.map((device) => (
                <tr key={device.id}>
                  <td>{device.model}</td>
                  <td>{device.manufacturer}</td>
                  <td>{device.category}</td>
                  <td>{device.retailPrice.toLocaleString("ru-RU")} ₽</td>
                  <td>{device.stock}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>

        <section id="tariffs" className="dashboard-card">
          <h3>Тарифы</h3>
          <table className="data-table">
            <thead>
              <tr>
                <th>Оператор</th>
                <th>Название</th>
                <th>Абонплата</th>
                <th>Минуты</th>
                <th>Интернет</th>
              </tr>
            </thead>
            <tbody>
              {tariffs.map((tariff) => (
                <tr key={tariff.id}>
                  <td>{tariff.operator}</td>
                  <td>{tariff.name}</td>
                  <td>{tariff.monthlyPrice} ₽</td>
                  <td>{tariff.minutes}</td>
                  <td>{tariff.internetGb} ГБ</td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>

        <section id="reports" className="dashboard-card">
          <h3>Отчёты по сотрудникам</h3>
          <table className="data-table">
            <thead>
              <tr>
                <th>Сотрудник</th>
                <th>Продажи</th>
                <th>Ремонты</th>
                <th>Выручка</th>
              </tr>
            </thead>
            <tbody>
              {employeePerformance.map((row) => (
                <tr key={row.employee}>
                  <td>{row.employee}</td>
                  <td>{row.deals}</td>
                  <td>{row.repairs}</td>
                  <td>{row.revenue}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>
      </div>
    </div>
  );
}
