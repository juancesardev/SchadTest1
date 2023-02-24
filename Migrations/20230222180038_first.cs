using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test4.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CustomerTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Status = table.Column<bool>(type: "bit", nullable: true),
            //        CustomerTypeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Customers_CustomerTypes_CustomerTypeId",
            //            column: x => x.CustomerTypeId,
            //            principalTable: "CustomerTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Invoice",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        TotalItbis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Invoice", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Invoice_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "InvoiceDetail",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        Qty = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TotalItbis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_InvoiceDetail_Invoice_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Invoice",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_CustomerTypeId",
            //    table: "Customers",
            //    column: "CustomerTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Invoice_CustomerId",
            //    table: "Invoice",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_InvoiceDetail_CustomerId",
            //    table: "InvoiceDetail",
            //    column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
