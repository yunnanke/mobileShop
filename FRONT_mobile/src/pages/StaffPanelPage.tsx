import { SectionTitle } from "../components/SectionTitle";
import { clientRepairs, recentSales } from "../data/mockData";

export function StaffPanelPage() {
  return (
    <div className="page-stack">
      <section className="dashboard-hero dashboard-hero--ink">
        <SectionTitle
          eyebrow="Сотрудник"
          title="Операционная панель"
          description="Поиск клиента, новые продажи, ремонты и договоры. Пока это UI-каркас на моках, без реальных вызовов функций из БД."
        />
      </section>

      <section className="action-grid">
        <article className="action-card">
          <span>Продажа</span>
          <h3>Новая продажа</h3>
          <p>Выбор клиента, серийные номера, итоговый чек и запуск будущего `f_register_sale`.</p>
        </article>
        <article className="action-card">
          <span>Ремонт</span>
          <h3>Новый ремонт</h3>
          <p>Приём устройства, описание проблемы, статус и сценарий для `f_close_repair`.</p>
        </article>
        <article className="action-card">
          <span>Договор</span>
          <h3>Новый договор</h3>
          <p>Пространство под создание договора с SIM через `f_create_contract_with_sim`.</p>
        </article>
      </section>

      <section className="dashboard-grid">
        <article className="dashboard-card">
          <h3>Последние продажи</h3>
          <div className="mini-table">
            {recentSales.map((sale) => (
              <div key={sale.id} className="mini-table__row">
                <div>
                  <strong>{sale.title}</strong>
                  <span>{sale.subtitle}</span>
                </div>
                <div>
                  <strong>{sale.amount}</strong>
                </div>
              </div>
            ))}
          </div>
        </article>

        <article className="dashboard-card">
          <h3>Активные ремонты</h3>
          <div className="mini-table">
            {clientRepairs.map((repair) => (
              <div key={repair.id} className="mini-table__row">
                <div>
                  <strong>{repair.serialNumber}</strong>
                  <span>{repair.issueType}</span>
                </div>
                <div>
                  <small>{repair.acceptedAt}</small>
                  <strong>{repair.status}</strong>
                </div>
              </div>
            ))}
          </div>
        </article>
      </section>
    </div>
  );
}
