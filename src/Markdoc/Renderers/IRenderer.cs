using Markdoc.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Markdoc.Renderers
{
    public interface IRenderer<TResult>
    {
        Task<TResult> Render(Document document);
    }
}
